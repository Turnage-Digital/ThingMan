import React, { FC, FormEvent } from "react";
import {
  Avatar,
  Box,
  Button,
  Container,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import { LockOutlined } from "@mui/icons-material";

import useAuth from "./use-auth";

const SignIn: FC = () => {
  const { login } = useAuth();

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    // eslint-disable-next-line no-console
    console.log({
      username: data.get("username"),
      password: data.get("password"),
    });
  };

  return (
    <Container component="main" maxWidth="xs" sx={{ mt: 8 }}>
      <Stack spacing={2} alignItems="center">
        <Avatar sx={{ m: 1, bgcolor: "primary.main", color: "white" }}>
          <LockOutlined />
        </Avatar>
        <Typography variant="h5">Sign in</Typography>

        <Box component="form" noValidate sx={{ mt: 1 }} onSubmit={handleSubmit}>
          <TextField
            margin="normal"
            required
            fullWidth
            name="username"
            id="username"
            label="Username"
            autoComplete="username"
          />
          <TextField
            margin="normal"
            required
            fullWidth
            name="password"
            id="password"
            label="Password"
            type="password"
            autoComplete="current-password"
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign In
          </Button>
        </Box>
      </Stack>
    </Container>
  );
};

export default SignIn;
