import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import { DashboardPage } from "./pages";
import SignInPage from "./pages/sign-in-page";
import Shell from "./shell";

// https://blog.logrocket.com/complete-guide-authentication-with-react-router-v6/
export const router = createBrowserRouter(
  createRoutesFromElements(
    <Route element={<Shell />}>
      <Route path="/" element={<DashboardPage />} />
      <Route path="/sign-in" element={<SignInPage />} />
    </Route>
  )
);
