import {
  FormLabel,
  Input,
  FormHelperText,
  FormErrorMessage,
  Grid,
  Box,
  Flex,
  FormControl,
  Textarea,
  Button,
  Stack,
  VStack,
  useBoolean,
  GridItem,
  Spinner,
  createStandaloneToast,
  Tooltip,
  Icon
} from "@chakra-ui/react";
import { CheckIcon } from "@chakra-ui/icons";
import * as yup from "yup";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useEffect, useMemo, useState } from "react";
import { GetWardPatient, Handover } from "../services/typescript-axios";
import { apiService } from "../services/axiosService";

import DatePicker from "react-datepicker";
import { DateInputGroup, localDate } from "./input/DateInputGroup";
import { HandoverHistory } from "./HandoverHistory";
import { delay, from, map, catchError, throwError } from "rxjs";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { GrClearOption } from "react-icons/gr";
import { useDebounce } from "react-use";
import { getPatientService } from "src/services/getPatientService";
import { handoverService } from "src/services/handoverService";
import { handoverlogService } from "src/services/handoverlogService";
import { handovergroupService } from "src/services/handoverGroupService";
export { HandoverForm };

type handoverInput = Handover & {
  editedDate: Date;
  groupName: string;
};
const handoverSchema = yup.object({
  id: yup.string(),
  patientKey: yup.string(),
  patientName: yup.string().required("Required"),
  dob: yup.date().nullable().notRequired(),
  sex: yup.string(),
  wardCode: yup.string(),
  specialtyCode: yup.string(),
  bedNumber: yup.string(),
  admissionTime: yup.date().nullable().notRequired(),
  caseNumber: yup.string(),
  diagnosis: yup.string().required("Required"),
  background: yup.string().required("Required"),
  progress: yup.string(),
  ix: yup.string(),
  drugs: yup.string(),
  recommendation: yup.string(),
  editedBy: yup.string(),
  editedDate: yup.date().notRequired(),
  freeText: yup.string().nullable()
});
const validateData = (v: any) => {
  handoverSchema
    .validate(v)
    .then((data) => console.log(data))
    .catch((err) => {
      console.log(err);
    });
};
function HandoverForm(props: any) {
  const [isSubmit, setIsSubmit] = useBoolean(false);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isFreeText, setIsFreeText] = useState<boolean>(false);

  const [patientKey, setPatientKey] = useState<string>();
  const [handoverId, setHandoverId] = useState<string>();

  const params = useParams();
  const pid = params.patientKey;

  const navigate = useNavigate();
  const location = useLocation();
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isDirty, isValid },
    reset,
    control,
    setValue,
    getValues
  } = useForm<handoverInput>({
    mode: "onBlur",
    resolver: yupResolver(handoverSchema)
  });

  useEffect(() => {
    if (pid && getPatientService.patientValue.patientKey !== pid) {
      apiService.pmi.pmiGetPatient(pid, { withCredentials: true }).then((p) => {
        getPatientService.send(p.data);
      });
    }
    return () => {};
  }, [pid]);

  useEffect(() => {
    if (handoverId && patientKey) {
      setIsLoading(true);
      let apiGetHistory = apiService.handover.handoverGetHandoverHistory(
        patientKey,
        handoverId,
        {
          withCredentials: true
        }
      );

      let rxGetHistory = from(apiGetHistory).pipe(
        delay(500),
        map((h) => {
          return h;
        }),
        catchError((err) => {
          return throwError(() => new Error(err));
        })
      );

      let rxGetHistorySubject = rxGetHistory.subscribe({
        next(r) {
          let h = r.data;
          handoverService.send(h);
          let groupName = handovergroupService.groupValue.groupName;
          let x = getPatientService.patientValue;
          reset({
            wardCode: x.wardCode,
            caseNumber: x.caseNumber,
            bedNumber: x.bedNumber,
            specialtyCode: x.specialtyCode,
            patientName: x.patientName,
            patientKey: x.patientKey,
            sex: x.sex,
            dob: x.dob,
            admissionTime: x.admissionTime,
            background: h.background,
            diagnosis: h.diagnosis,
            progress: h.progress,
            ix: h.ix,
            drugs: h.drugs,
            recommendation: h.recommendation,
            editedBy: h.editedBy,
            editedDate: handoverlogService.logValue?.logTime,
            freeText: h.freeText,
            groupId: h.groupId,
            groupName: groupName ? groupName : ""
          });
        },
        error(err: Response) {
          if (err.status === 401) {
          }
          if (err.status === 404) {
          }
        },
        complete() {
          rxGetHistorySubject.unsubscribe();
          setIsLoading(false);
        }
      });
    }
  }, [handoverId, reset, patientKey]);

  const [ready, cancel] = useDebounce(
    () => {
      if (patientKey) {
        let x = getPatientService.patientValue;
        if (x?.patientName) {
          reset({
            wardCode: x.wardCode,
            caseNumber: x.caseNumber,
            bedNumber: x.bedNumber,
            specialtyCode: x.specialtyCode,
            patientName: x.patientName,
            patientKey: x.patientKey,
            sex: x.sex,
            dob: x.dob,
            admissionTime: x.admissionTime,
            background: "",
            diagnosis: "",
            progress: "",
            ix: "",
            drugs: "",
            recommendation: "",
            editedBy: "",
            editedDate: undefined,
            freeText: "",
            groupId: undefined,
            groupName: ""
          });
        }
        navigate("/home/" + x?.patientKey);
      } else {
        reset({
          wardCode: "",
          caseNumber: "",
          bedNumber: "",
          specialtyCode: "",
          patientName: "",
          patientKey: "",
          sex: "",
          dob: undefined,
          admissionTime: undefined,
          background: "",
          diagnosis: "",
          progress: "",
          ix: "",
          drugs: "",
          recommendation: "",
          editedBy: "",
          editedDate: undefined,
          freeText: "",
          groupId: undefined,
          groupName: ""
        });
        navigate("/home/");
      }
    },
    500,
    [patientKey]
  );

  useEffect(() => {
    const patientSubscriber = getPatientService.subject.subscribe((x) => {
      setHandoverId(undefined);
      setPatientKey(x?.patientKey);
    });

    const logSubscriber = handoverlogService.subject.subscribe((l) => {
      if (patientKey && l?.id) {
        setHandoverId(l?.id);
      }
    });

    return () => {
      patientSubscriber.unsubscribe();
      logSubscriber.unsubscribe();
    };
  }, [navigate, reset, patientKey]);

  const onSubmit = (values: handoverInput) => {
    let api = apiService.handover;
    setIsSubmit.on();
    values.groupId = handovergroupService.groupValue.id;
    api
      .handoverPostHandover(values, values.groupId, {
        withCredentials: true
      })
      .then((h) => {
        getPatientService.resend();
        setIsSubmit.off();
        const toast = createStandaloneToast();
        toast({
          title: `Success`,
          description: `Saved`,
          status: "success",
          duration: 500,
          isClosable: true,
          position: "bottom-right"
        });
        props.handleRefresh();
      });
  };

  const handleClearAll = () => {
    getPatientService.send({} as GetWardPatient);
  };

  const setBackgroundColor = useMemo(() => {
    return isFreeText ? "white" : "gray.100";
  }, [isFreeText]);

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Input
        type={"hidden"}
        isReadOnly
        size={"sm"}
        fontSize={"sm"}
        {...register("groupId")}
        backgroundColor={"gray.100"}
      />
      <Flex direction={{ base: "column", lg: "row" }}>
        <Box flex={2}>
          <Box backgroundColor="white" mb={2}>
            <Stack spacing={2}>
              <Flex justify="space-between">
                <Stack direction="row" spacing={4}></Stack>
                <Stack direction="row" spacing={4}>
                  <Tooltip
                    hasArrow
                    label="Reset handover form"
                    aria-label="Reset handover form">
                    <Button
                      onClick={handleClearAll}
                      leftIcon={
                        <Icon
                          as={GrClearOption}
                          w={6}
                          h={6}
                          stroke={"yellow.600"}
                          fill={"transparent"}
                        />
                      }
                      colorScheme="yellow"
                      variant="ghost">
                      Clear form
                    </Button>
                  </Tooltip>

                  <Stack align="center" direction="row"></Stack>

                  <Button
                    w={"140px"}
                    isDisabled={!(isDirty && isValid)}
                    isLoading={isSubmit}
                    leftIcon={<CheckIcon />}
                    colorScheme="green"
                    variant="solid"
                    type="submit">
                    Save
                  </Button>
                </Stack>
              </Flex>
              <VStack
                backgroundColor={"teal.50"}
                align={"left"}
                pl={2}
                pr={2}
                pb={2}
                border="2px"
                borderRadius="10px"
                borderColor="teal.500">
                <Flex justify={"space-between"}>
                  <FormLabel fontSize="lg" mb={0} fontWeight="bold">
                    Handover
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
                <Grid
                  templateColumns={{
                    md: "1fr 1fr 1fr",
                    lg: "1fr 2fr 2fr"
                  }}
                  gap={2}>
                  <FormControl
                    isReadOnly
                    isInvalid={!!errors?.editedBy?.message}>
                    <FormLabel fontSize={"sm"}>{"Edited By"}</FormLabel>
                    <Input
                      isReadOnly
                      size={"sm"}
                      fontSize={"sm"}
                      {...register("editedBy")}
                      backgroundColor={"gray.100"}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.editedBy?.message}
                    </FormErrorMessage>
                  </FormControl>
                  <FormControl
                    isReadOnly
                    isInvalid={!!errors?.editedDate?.message}>
                    <FormLabel fontSize={"sm"}>{"Edited Date"}</FormLabel>
                    <Controller
                      control={control}
                      name="editedDate"
                      render={({ field: { onChange, onBlur, value, ref } }) => {
                        return (
                          <DatePicker
                            disabled={true}
                            readOnly={true}
                            onChange={onChange} // send value to hook form
                            onBlur={onBlur} // notify when input is touched/blur
                            selected={localDate(value)}
                            customInput={<DateInputGroup />}
                            dateFormat={"yyyy-MM-dd HH:mm:ss"}
                          />
                        );
                      }}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.editedDate?.message}
                    </FormErrorMessage>
                  </FormControl>
                  <FormControl
                    isReadOnly
                    isInvalid={!!errors?.groupId?.message}>
                    <FormLabel fontSize={"sm"}>{"Group"}</FormLabel>
                    <Input
                      isReadOnly
                      size={"sm"}
                      fontSize={"sm"}
                      {...register("groupName")}
                      backgroundColor={"gray.100"}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.groupId?.message}
                    </FormErrorMessage>
                  </FormControl>
                </Grid>
              </VStack>

              <VStack
                backgroundColor={"gray.50"}
                align={"left"}
                pl={2}
                pr={2}
                border="2px"
                borderRadius="10px"
                borderColor="gray.500">
                <FormLabel fontSize="lg" mb={0} fontWeight="bold">
                  Identification
                </FormLabel>
                <Grid
                  templateColumns={{
                    md: "1fr 1fr 1fr",
                    lg: "1fr 1fr 1fr 1fr 1fr"
                  }}
                  gap={2}>
                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.caseNumber?.message}>
                    <FormLabel fontSize={"sm"}>{"Case Number"}</FormLabel>
                    <Input
                      isReadOnly={!isFreeText}
                      size={"sm"}
                      {...register("caseNumber")}
                      backgroundColor={setBackgroundColor}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.caseNumber?.message}
                    </FormErrorMessage>
                  </FormControl>
                  <GridItem colSpan={{ sm: 1, md: 2 }}>
                    <FormControl
                      isRequired
                      isReadOnly={!isFreeText}
                      isInvalid={!!errors?.patientName?.message}>
                      <FormLabel fontSize={"sm"}>Patient Name</FormLabel>
                      <Input
                        isReadOnly={!isFreeText}
                        size={"sm"}
                        {...register("patientName")}
                        backgroundColor={setBackgroundColor}
                      />
                      <FormErrorMessage>
                        {errors?.patientName?.message}
                      </FormErrorMessage>
                    </FormControl>
                  </GridItem>
                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.wardCode?.message}>
                    <FormLabel fontSize={"sm"}>{"Ward"}</FormLabel>
                    <Input
                      isReadOnly={!isFreeText}
                      size={"sm"}
                      {...register("wardCode")}
                      backgroundColor={setBackgroundColor}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.wardCode?.message}
                    </FormErrorMessage>
                  </FormControl>

                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.specialtyCode?.message}>
                    <FormLabel fontSize={"sm"}>{"Specialty"}</FormLabel>
                    <Input
                      isReadOnly={!isFreeText}
                      size={"sm"}
                      {...register("specialtyCode")}
                      backgroundColor={setBackgroundColor}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.specialtyCode?.message}
                    </FormErrorMessage>
                  </FormControl>
                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.bedNumber?.message}>
                    <FormLabel fontSize={"sm"}>{"Bed"}</FormLabel>
                    <Input
                      isReadOnly={!isFreeText}
                      size={"sm"}
                      {...register("bedNumber")}
                      backgroundColor={setBackgroundColor}
                    />
                    <FormErrorMessage fontSize={"sm"}>
                      {errors?.bedNumber?.message}
                    </FormErrorMessage>
                  </FormControl>

                  <GridItem colSpan={{ md: 1, lg: 2 }}>
                    <FormControl
                      isReadOnly
                      isInvalid={!!errors?.admissionTime?.message}>
                      <FormLabel fontSize={"sm"}>Admission</FormLabel>
                      <Controller
                        control={control}
                        name="admissionTime"
                        render={({
                          field: { onChange, onBlur, value, ref }
                        }) => (
                          <DatePicker
                            disabled={!isFreeText}
                            readOnly={!isFreeText}
                            onChange={onChange} // send value to hook form
                            onBlur={onBlur} // notify when input is touched/blur
                            selected={localDate(value)}

                            customInput={<DateInputGroup />}
                            dateFormat={"yyyy-MM-dd HH:mm"}
                          />
                        )}
                      />
                      <FormErrorMessage>
                        {errors?.admissionTime?.message}
                      </FormErrorMessage>
                      <FormHelperText></FormHelperText>
                    </FormControl>
                  </GridItem>

                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.sex?.message}>
                    <FormLabel fontSize={"sm"}>Sex</FormLabel>
                    <Input
                      isReadOnly={!isFreeText}
                      size={"sm"}
                      {...register("sex")}
                      backgroundColor={setBackgroundColor}
                    />
                    <FormErrorMessage>{errors?.sex?.message}</FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                  <FormControl
                    isReadOnly={!isFreeText}
                    isInvalid={!!errors?.dob?.message}>
                    <FormLabel fontSize={"sm"}>DOB</FormLabel>
                    <Controller
                      control={control}
                      name="dob"
                      render={({ field: { onChange, onBlur, value, ref } }) => (
                        <DatePicker
                          disabled={!isFreeText}
                          readOnly={!isFreeText}
                          onChange={onChange} // send value to hook form
                          onBlur={onBlur} // notify when input is touched/blur
                          selected={localDate(value)}

                          customInput={<DateInputGroup />}
                          dateFormat={"yyyy-MM-dd"}
                        />
                      )}
                    />
                    <FormErrorMessage>{errors?.dob?.message}</FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                </Grid>
                {isFreeText || getValues("freeText") ? (
                  <FormControl isInvalid={!!errors?.freeText?.message}>
                    <Flex>
                      <FormLabel fontSize={"sm"}>{"Notes"}</FormLabel>
                    </Flex>
                    <Textarea {...register("freeText")} />
                    <FormErrorMessage>
                      {errors?.freeText?.message}
                    </FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                ) : (
                  <></>
                )}
              </VStack>
            </Stack>
          </Box>
          <Box backgroundColor="white" mb={2}>
            <Stack spacing={2}>
              <Stack
                pl={2}
                pr={2}
                border="2px"
                borderRadius="10px"
                borderColor="orange.500"
                backgroundColor={"orange.50"}>
                <FormLabel fontSize="lg" mb={0} fontWeight="bold">
                  Situation
                </FormLabel>
                <FormControl
                  isRequired
                  isInvalid={!!errors?.diagnosis?.message}>
                  <Flex>
                    <FormLabel fontSize={"sm"}>{"Diagnosis"}</FormLabel>
                  </Flex>

                  <Textarea {...register("diagnosis")} />
                  <FormErrorMessage>
                    {errors?.diagnosis?.message}
                  </FormErrorMessage>
                  <FormHelperText></FormHelperText>
                </FormControl>
              </Stack>

              <Stack
                pl={2}
                pr={2}
                border="2px"
                borderRadius="10px"
                borderColor="blue.500"
                backgroundColor={"blue.50"}>
                <FormLabel fontSize="lg" mb={0} fontWeight="bold">
                  Background & Assessment
                </FormLabel>

                <Grid templateColumns={"1fr 1fr"} gap={2}>
                  <FormControl
                    isRequired
                    isInvalid={!!errors?.background?.message}>
                    <FormLabel fontSize={"sm"}>Background</FormLabel>
                    <Textarea {...register("background")} />
                    <FormErrorMessage>
                      {errors?.background?.message}
                    </FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                  <FormControl isInvalid={!!errors?.progress?.message}>
                    <FormLabel fontSize={"sm"}>Progress</FormLabel>
                    <Textarea {...register("progress")} />
                    <FormErrorMessage>
                      {errors?.progress?.message}
                    </FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                  <FormControl isInvalid={!!errors?.ix?.message}>
                    <FormLabel fontSize={"sm"}>Ix</FormLabel>
                    <Textarea {...register("ix")} />
                    <FormErrorMessage>{errors?.ix?.message}</FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                  <FormControl isInvalid={!!errors?.drugs?.message}>
                    <FormLabel fontSize={"sm"}>Drugs</FormLabel>
                    <Textarea {...register("drugs")} />
                    <FormErrorMessage>
                      {errors?.drugs?.message}
                    </FormErrorMessage>
                    <FormHelperText></FormHelperText>
                  </FormControl>
                </Grid>
              </Stack>

              <Stack
                pl={2}
                pr={2}
                border="2px"
                borderRadius="10px"
                borderColor="green.500"
                backgroundColor="green.50">
                <FormControl isInvalid={!!errors?.recommendation?.message}>
                  <FormLabel fontSize="lg" mb={0} fontWeight="bold">
                    Recommendation
                  </FormLabel>
                  <Textarea {...register("recommendation")} />
                  <FormErrorMessage>
                    {errors?.recommendation?.message}
                  </FormErrorMessage>
                  <FormHelperText></FormHelperText>
                </FormControl>
              </Stack>
            </Stack>
          </Box>
        </Box>

        <Box w={"230px"} h={{ md: "600px", lg: "920px" }} pl={{ lg: 4 }}>
          <HandoverHistory
            handleRefresh={props.handleRefresh}></HandoverHistory>
        </Box>
      </Flex>
    </form>
  );
}
