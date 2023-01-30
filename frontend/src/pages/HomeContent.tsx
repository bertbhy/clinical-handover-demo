import React, { useState, useEffect, useRef, useCallback } from "react";
import { Box, Text, HStack } from "@chakra-ui/react";
import {
  Accordion,
  AccordionItem,
  AccordionButton,
  AccordionPanel
} from "@chakra-ui/react";
import { PatientGrid } from "../components/grid/DataGridPatient";
import { HandoverForm } from "../components/HandoverForm";
import { userService } from "src/services/userService";
import { FaBed, FaListUl, FaPen } from "react-icons/fa";
import { LoginResponse } from "../services/typescript-axios";

import { delay, of } from "rxjs";
import { HandoverGrid } from "../components/grid/DataGridHandover";
import { useParams } from "react-router-dom";
import DatePicker from "react-datepicker";
import { DateInputGroup } from "../components/input/DateInputGroup";
import { handoverService } from "src/services/handoverService";
import { handovergroupService } from "src/services/handoverGroupService";

export default HomeContent;

function HomeContent(): JSX.Element {
  const pGrid = useRef<PatientGrid>(null);
  const hGrid = useRef<HandoverGrid>(null);
  const [showGrid, setShowGrid] = useState<Boolean>(false);
  const [handoverDate, setHandoverDate] = useState<Date>(
    handoverService.dateValue
  );
  const [user, setUser] = useState<LoginResponse>(userService?.userValue);

  let params = useParams();
  const pid = params.patientKey;
  const handleRefresh = useCallback(() => {
    if (user && user.token) {
      pGrid.current?.refresh();
      hGrid.current?.refresh();
    }else{
      pGrid.current?.clear();
      hGrid.current?.clear();
    }
  }, [user]);
  useEffect(() => {
    const userSubject = userService.user.subscribe((x) => setUser(x));
    return () => {
      userSubject.unsubscribe();
    };
  }, []);
  useEffect(() => {
    const groupSubject = handovergroupService.subject.subscribe((x) => {
      if (x) handleRefresh();
    });
    return () => {
      groupSubject.unsubscribe();
    };
  }, [handleRefresh]);
  useEffect(() => {
    let r = of([0]).pipe(delay(500));
    const rxLoadGridSubject = r.subscribe((d) => {
      setShowGrid(true);
      //handleRefresh();
    });

    return () => {
      rxLoadGridSubject.unsubscribe();
    };
  }, [handleRefresh, user]);

  const handleFocusP = () => {
    hGrid.current?.clearSelection();
  };
  const handleFocusG = () => {
    pGrid.current?.clearSelection();
  };

  const handleHandoverDate = (d: Date) => {
    setHandoverDate(d);
    handoverService.sendDate(d);
    hGrid.current?.refresh();
  };

  return (
    <Box textAlign="center" fontSize="xl">
      <Accordion allowMultiple index={[0, 1, 2]}>
        <AccordionItem backgroundColor={"blue.50"}>
          <h2>
            <AccordionButton as={Box}>
              <Box flex={1} textAlign={"left"}>
                <HStack>
                  <Box sx={{ left: "10px" }} color={"gray.400"}>
                    <FaBed />
                  </Box>
                  <Text color={"gray.500"}>Ward Patients</Text>
                </HStack>
              </Box>
            </AccordionButton>
          </h2>
          <AccordionPanel pb={4} onFocus={handleFocusP}>
            {!showGrid ? <></> : <PatientGrid ref={pGrid}></PatientGrid>}
          </AccordionPanel>
        </AccordionItem>
        <AccordionItem backgroundColor={"green.50"}>
          <h2>
            <AccordionButton as={Box}>
              <Box flex={1} textAlign={"left"}>
                <HStack>
                  <Box sx={{ left: "10px" }} color={"gray.400"}>
                    <FaListUl />
                  </Box>
                  <Text color={"gray.500"}>Handover List</Text>
                  <Box>
                    <DatePicker
                      onChange={handleHandoverDate} // send value to hook form
                      selected={handoverDate}
                      customInput={<DateInputGroup />}
                      dateFormat={"yyyy-MM-dd"}
                    />
                  </Box>
                </HStack>
              </Box>
            </AccordionButton>
          </h2>
          <AccordionPanel pb={4} onFocus={handleFocusG}>
            {!showGrid ? <></> : <HandoverGrid ref={hGrid}></HandoverGrid>}
          </AccordionPanel>
        </AccordionItem>
        <AccordionItem>
          <h2>
            <AccordionButton as={Box}>
              <Box flex="1" textAlign="left">
                <HStack>
                  <Box sx={{ left: "10px" }} color={"gray.400"}>
                    <FaPen />
                  </Box>
                  <Text color={"gray.500"}>Handover Form</Text>
                </HStack>
              </Box>
            </AccordionButton>
          </h2>
          <AccordionPanel pb={4}>
            <HandoverForm handleRefresh={handleRefresh}></HandoverForm>
          </AccordionPanel>
        </AccordionItem>
      </Accordion>
    </Box>
  );
}
