import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import { DashboardPage } from "./pages";
import Shell from "./shell";

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Shell />}>
        <Route path="/" element={<DashboardPage />} />
      </Route>
    </>
  )
);

export default router;
