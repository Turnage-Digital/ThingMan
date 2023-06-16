import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import { HomePage, ThingDefsPage, CreateThingDefPage } from "./pages";
import Shell from "./shell";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Shell />}>
      <Route element={<HomePage />} index />
      <Route path="thing-defs">
        <Route element={<ThingDefsPage />} index />
        <Route path="create" element={<CreateThingDefPage />} />
      </Route>
    </Route>
  )
);

export default router;
