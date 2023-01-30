import { useState, useEffect } from "react";
import {
  Box,
  Flex,
  Avatar,
  HStack,
  IconButton,
  Button,
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  MenuDivider,
  useDisclosure,
  useColorModeValue,
  Stack,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  Text,
  MenuOptionGroup,
  VStack,
  MenuItemOption
} from "@chakra-ui/react";
import { HamburgerIcon, CloseIcon, ChevronDownIcon } from "@chakra-ui/icons";
import { userService } from "../services/userService";
import { LoginForm } from "./LoginForm";
import { HandoverGroup, LoginResponse } from "../services/typescript-axios";
import { Link } from "react-router-dom";
import { FaHandsHelping, FaHome } from "react-icons/fa";
import { apiService } from "src/services/axiosService";
import { handovergroupService } from "src/services/handoverGroupService";
export { NavBar };

function NavBar() {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const [user, setUser] = useState<LoginResponse>();
  const [userGroup, setUserGroup] = useState<HandoverGroup>();
  const [groupList, setGroupList] = useState<HandoverGroup[]>();

  useEffect(() => {
    if (user && user.token) 
      apiService.handover
      .handoverGetHandoverGroups({ withCredentials: true })
      .then((g) => {
        setGroupList(g.data);
        handovergroupService.send(g.data[0]);
      })
      .catch((err) => {
        userService.logout();
      });
  }, [user]);

  useEffect(() => {
    const userSubject = userService.user.subscribe((x) => setUser(x));
    return () => {
      userSubject.unsubscribe();
    };
  }, []);
  useEffect(() => {
      const groupSubject = handovergroupService.subject.subscribe((x) =>
        setUserGroup(x)
      );
      return () => {
        groupSubject.unsubscribe();
      };
  }, []);

  function logout() {
    userService.logout();
  }

  function GroupButton() {
    return (
      <Box>
        <Menu>
          <MenuButton as={Button} colorScheme="gray" variant="ghost">
            {userGroup?.groupName}
            <ChevronDownIcon />
          </MenuButton>
          <MenuList>
            <MenuOptionGroup
              title="Groups"
              type="radio"
              onChange={(v) => {
                handovergroupService.send(
                  groupList?.find((g) => g.id.toString() === v) as HandoverGroup
                );
              }}>
              {groupList?.map((v, i, a) => {
                return (
                  <MenuItemOption value={v.id.toString()} key={v.id}>
                    {v.groupName}
                  </MenuItemOption>
                );
              })}
            </MenuOptionGroup>
          </MenuList>
        </Menu>
      </Box>
    );
  }

  return (
    <>
      <Box bg={useColorModeValue("cyan.50", "cyan.900")} px={4}>
        <Flex h={16} alignItems={"center"} justifyContent={"space-between"}>
          <IconButton
            size={"md"}
            icon={isOpen ? <CloseIcon /> : <HamburgerIcon />}
            aria-label={"Open Menu"}
            display={{ md: "none" }}
            onClick={isOpen ? onClose : onOpen}
          />
          <HStack spacing={8} alignItems={"center"}>
            <HStack spacing={2}>
              <Box sx={{ left: "10px" }} color={"cyan.900"}>
                <FaHandsHelping size={"28px"} />
              </Box>
              <VStack spacing={0} align={"right"}>
                <Text fontSize={"xl"} color={"cyan.900"}>
                  Smart Clinical Handover
                </Text>
                <Text
                  fontSize="xs"
                  textAlign={"right"}
                  lineHeight={"0"}
                  color={"gray.200"}>
                  {process.env.REACT_APP_ENV?.toString()}
                </Text>
              </VStack>
            </HStack>

            <HStack
              as={"nav"}
              spacing={4}
              display={{ base: "none", md: "flex" }}>
              <Link to={"home"}>
                <Box sx={{ left: "10px" }} color={"cyan.900"}>
                  <FaHome size={"28px"} />
                </Box>
              </Link>
              <GroupButton></GroupButton>
            </HStack>
          </HStack>
          <Flex alignItems={"center"} gap={4}>
            <Menu>
              <MenuButton
                as={Button}
                rounded={"full"}
                variant={"link"}
                cursor={"pointer"}
                minW={0}>
                <Avatar size={"sm"} src={""} />
              </MenuButton>
              <MenuList>
                <MenuItem>{user?.person?.displayName}</MenuItem>
                <MenuDivider />
                <MenuItem onClick={logout}>Logout </MenuItem>
              </MenuList>
            </Menu>
          </Flex>
        </Flex>

        {isOpen ? (
          <Box pb={4} display={{ md: "none" }}>
            <Stack as={"nav"} spacing={4}>
              <Link to={"home"}>
                <Button>{"Home"}</Button>
              </Link>
              <GroupButton></GroupButton>
            </Stack>
          </Box>
        ) : null}

        <Modal isOpen={!user?.token} onClose={() => {}}>
          <ModalOverlay blur={"100px"} />
          <ModalContent>
            <ModalHeader>Login</ModalHeader>
            <ModalBody>
              <LoginForm></LoginForm>
            </ModalBody>
            <ModalFooter></ModalFooter>
          </ModalContent>
        </Modal>
      </Box>
    </>
  );
}
