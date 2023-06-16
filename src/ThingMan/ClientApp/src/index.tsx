import React from "react";
import {
  CssBaseline,
  StyledEngineProvider,
  ThemeProvider,
} from "@mui/material";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { createRoot } from "react-dom/client";
import { RouterProvider } from "react-router-dom";

import { IUserApi, UserApi } from "./api";
import { AuthProvider } from "./auth";
import reportWebVitals from "./reportWebVitals";
import router from "./router";
import theme from "./theme";

const rootElement = document.getElementById("root");
const root = createRoot(rootElement!);

const userApi: IUserApi = new UserApi(`${process.env.PUBLIC_URL}/api/users`);

root.render(
  <AuthProvider userApi={userApi}>
    <StyledEngineProvider injectFirst>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <LocalizationProvider dateAdapter={AdapterDateFns}>
          <RouterProvider router={router} />
        </LocalizationProvider>
      </ThemeProvider>
    </StyledEngineProvider>
  </AuthProvider>
);

// eslint-disable-next-line no-console
reportWebVitals(console.log);
