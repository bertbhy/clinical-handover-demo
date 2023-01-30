import {
  VStack,
  FormLabel,
  Flex,
  createStandaloneToast,
  Button,
  Icon,
  Popover,
  PopoverTrigger,
  Portal,
  PopoverContent,
  PopoverHeader,
  PopoverCloseButton,
  PopoverBody,
  PopoverFooter,
  HStack
} from "@chakra-ui/react";
import { Stat, StatLabel, StatHelpText, Spinner } from "@chakra-ui/react";
import { Radio, RadioGroup } from "@chakra-ui/react";
import { format } from "date-fns";
import { useEffect, useState, useRef } from "react";
import { apiService } from "src/services/axiosService";
import { HandoverLog } from "../services/typescript-axios";
import { delay, from, map, catchError, throwError } from "rxjs";
import { FiXSquare } from "react-icons/fi";
import { handoverlogService } from "src/services/handoverlogService";
import { getPatientService } from "src/services/getPatientService";
import { handoverService } from "src/services/handoverService";
import { localDate } from "./input/DateInputGroup";

function HandoverHistory(props: any) {
  const [log, setLog] = useState<HandoverLog[]>();
  const [select, setSelect] = useState<number>(0);
  const [isLoading, setIsLoading] = useState<Boolean>(false);

  const inputRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (log) {
      let selectedLog = log as HandoverLog[];
      handoverlogService.send(selectedLog[select]);
    }
  }, [select, log]);

  useEffect(() => {
    const subscription = getPatientService.subject.subscribe((x) => {
      if (x?.patientKey !== undefined) {
        setIsLoading(true);
        handoverlogService.send({} as HandoverLog);
        setLog([]);
        let apiGetLog = apiService.handover.handoverGetHandoverLog(
          x?.patientKey as string,
          {
            withCredentials: true
          }
        );

        let r = from(apiGetLog).pipe(
          delay(200),
          map((h) => h),
          catchError((err) => {
            return throwError(() => {
              return err;
            });
          })
        );

        let rxGetLogSubject = r.subscribe({
          next(l) {
            setLog(l.data);
            if (l.data) {
              for (let i = 0; i < l.data.length; i++) {
                if (l.data[i].logText === "Delete") continue;
                setSelect(i);
                break;
              }
            }
          },
          error(err) {
            setLog([]);
            if (err.status === 401) {
              const toast = createStandaloneToast();
              toast({
                title: `${err.status}`,
                description: `${err.error}`,
                status: "error",
                duration: 500,
                isClosable: true,
                position: "bottom-right"
              });
            }
            if (err.status === 404) {
            }
          },
          complete() {
            rxGetLogSubject.unsubscribe();
            setIsLoading(false);
          }
        });
      } else {
        setLog([]);
      }
    });
    return () => subscription.unsubscribe();
  }, []);

  const handleHistoryChange = (r) => {
    setSelect(parseInt(r));
  };

  const handleDelete = (r) => {
    let handoverId = handoverService.handoverValue.id;
    apiService.handover
      .handoverDeleteHandover(handoverId as string, {
        withCredentials: true
      })
      .then(() => {
        getPatientService.resend();
        props.handleRefresh();
      });
  };

  return (
    <VStack
      h={"100%"}
      p={4}
      backgroundColor={"gray.50"}
      align={"left"}
      border="2px"
      borderRadius="10px"
      borderColor="gray.500">
      <Flex justify="space-between">
        <FormLabel fontSize="xl" fontWeight="bold">
          Log
        </FormLabel>
        {isLoading ? (
          <Spinner
            thickness="4px"
            speed="0.65s"
            emptyColor="gray.200"
            color="blue.500"
            size="md"
          />
        ) : (
          <></>
        )}
      </Flex>
      {log && log[0] ? (
        <Popover>
          {({ isOpen, onClose }) => (
            <>
              <PopoverTrigger>
                <Button
                  size={"xs"}
                  colorScheme="red"
                  variant="ghost"
                  leftIcon={
                    <Icon
                      as={FiXSquare}
                      w={6}
                      h={6}
                      stroke={"red.600"}
                      fill={"transparent"}
                    />
                  }>
                  {log[0]?.logText === "Delete"
                    ? "Deleted"
                    : "Delete handover ?"}
                </Button>
              </PopoverTrigger>
              <Portal>
                {log[0]?.logText === "Delete" ? (
                  <></>
                ) : (
                  <PopoverContent>
                    <PopoverHeader>Confirm to delete ?</PopoverHeader>
                    <PopoverCloseButton />
                    <PopoverBody>
                      <HStack spacing={4}>
                        <Button colorScheme="red" onClick={handleDelete}>
                          Yes
                        </Button>
                        <Button variant={"outline"} onClick={onClose}>
                          No
                        </Button>
                      </HStack>
                    </PopoverBody>
                    <PopoverFooter>Exclude handover from report</PopoverFooter>
                  </PopoverContent>
                )}
              </Portal>
            </>
          )}
        </Popover>
      ) : (
        <></>
      )}

      <VStack overflowY={"scroll"} w="100%" p={"10px"}>
        <VStack spacing={4} direction="row" justify={"left"} textAlign={"left"}>
          <RadioGroup
            ref={inputRef}
            onChange={handleHistoryChange}
            value={select}>
            {log?.map(function (item, value) {
              return (
                <Radio
                  value={value}
                  key={value}
                  isDisabled={item.logText === "Delete"}>
                  <Stat textAlign={"left"}>
                    <StatLabel>{item.logText}</StatLabel>
                    <StatLabel>{item.logBy}</StatLabel>
                    <StatHelpText>
                      {format(localDate(item.logTime)as Date, "yyyy-MM-dd HH:mm:ss")}
                    </StatHelpText>
                  </Stat>
                </Radio>
              );
            })}
          </RadioGroup>
        </VStack>
      </VStack>
    </VStack>
  );
}

export { HandoverHistory };
