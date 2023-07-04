import {Alert, Box, Button, Container, Stack, TextField, Typography,} from "@mui/material";
import React, {FC, FormEvent} from "react";

import useAuth from "./use-auth";

const SignInForm: FC = () => {
    const {signIn, error} = useAuth();

    const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        const username = data.get("username")?.toString();
        const password = data.get("password")?.toString();

        if (username && password && signIn) {
            await signIn(username, password);
        }
    };

    return (
        <Container component="main" maxWidth="xs" sx={{mt: 8}}>
            <Stack spacing={2} alignItems="center">
                <Typography variant="h5">Sign in</Typography>

                <Box component="form" noValidate sx={{mt: 1}} onSubmit={handleSubmit}>
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
                        variant="contained"
                        size="large"
                        fullWidth
                        sx={{my: 2}}
                    >
                        Sign In
                    </Button>
                </Box>

                {error && (
                    <Alert sx={{mt: 2}} severity="error">
                        {error}
                    </Alert>
                )}
            </Stack>
        </Container>
    );
};

export default SignInForm;
