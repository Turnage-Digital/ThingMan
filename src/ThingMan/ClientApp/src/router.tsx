import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import { CreateThingDefPage, DashboardPage } from "./pages";
import Shell from "./shell";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Shell />}>
      <Route index element={<DashboardPage />} />
      <Route path="/thing-def/create" element={<CreateThingDefPage />} />
    </Route>
  )
);

export default router;
