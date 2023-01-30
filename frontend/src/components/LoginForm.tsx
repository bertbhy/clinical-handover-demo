import {
  FormControl,
  FormLabel,
  FormErrorMessage,
  Input,
  Button
} from "@chakra-ui/react";
import * as yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { userService } from "../services/userService";
import { LoginRequest } from "../services/typescript-axios";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
export { LoginForm };

const schema = yup.object().shape({
  username: yup.string().required(),
  password: yup.string().min(8).required()
});

type LoginFormInputs = {
  username: string;
  password: string;
  apiError: string;
};

function LoginForm() {
  let history = useNavigate();
  const [isLoading, setIsLoading] = useState<Boolean>(false);

  const {
    register,
    handleSubmit,
    setError,
    formState: { errors }
  } = useForm<LoginFormInputs>({
    mode: "onSubmit",
    resolver: yupResolver(schema)
  });

  const onSubmit = (values: LoginRequest) => {
    setIsLoading(true);
    return userService
      .login(values)
      .then(() => {})
      .catch((error) => {
        setError("apiError", { message: error });
      })
      .finally(() => {
        setIsLoading(false);
      });
  };

  return (
    <form style={{ width: 350 }} onSubmit={handleSubmit(onSubmit)}>
      <FormControl isInvalid={!!errors?.username?.message} p="4" isRequired>
        <FormLabel>Username</FormLabel>
        <Input
          type="text"
          placeholder="Username"
          {...register("username")}
          autoComplete="username"
        />
        <FormErrorMessage>{errors?.username?.message}</FormErrorMessage>
        {/* <FormHelperText>User: demo / Password: demodemo</FormHelperText> */}
      </FormControl>
      <FormControl
        isInvalid={!!errors?.password?.message}
        px="4"
        pb="4"
        isRequired>
        <FormLabel>Password</FormLabel>
        <Input
          {...register("password")}
          type="password"
          placeholder="Password"
          autoComplete="current-password"
        />
        <FormErrorMessage>{errors?.password?.message}</FormErrorMessage>
        <FormErrorMessage>{errors?.apiError?.message}</FormErrorMessage>
      </FormControl>
      <Button
        type="submit"
        p="4"
        mx="4"
        mt="6"
        w="90%"
        colorScheme="blue"
        variant="solid"
        disabled={!!errors.username || !!errors.password}
        isLoading={isLoading === true}
        loadingText="loading">
        Login
      </Button>
    </form>
  );
}
