import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import DashboardPage from "./dashboard-page";
import Shell from "./shell";

export const router = createBrowserRouter(
  createRoutesFromElements(
    <Route element={<Shell />}>
      <Route path="/" element={<DashboardPage />} />
    </Route>
  )
);
