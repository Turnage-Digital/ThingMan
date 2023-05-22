import React from "react";
import {
  CssBaseline,
  StyledEngineProvider,
  ThemeProvider,
} from "@mui/material";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { createRoot } from "react-dom/client";
import { Provider as ReduxProvider } from "react-redux";
import { RouterProvider } from "react-router-dom";

import reportWebVitals from "./reportWebVitals";
import { router } from "./router";
import { store } from "./store";
import theme from "./theme";

const rootElement = document.getElementById("root");
const root = createRoot(rootElement!);

root.render(
  <StyledEngineProvider injectFirst>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <LocalizationProvider dateAdapter={AdapterDateFns}>
        <ReduxProvider store={store}>
          <RouterProvider router={router} />
        </ReduxProvider>
      </LocalizationProvider>
    </ThemeProvider>
  </StyledEngineProvider>
);

// eslint-disable-next-line no-console
reportWebVitals(console.log);
