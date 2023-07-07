import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import HomePage from "./pages/home/home-page";
import CreateThingDefPage from "./pages/thing-defs/create/create-thing-def-page";
import ThingDefsPage from "./pages/thing-defs/thing-defs-page";
import Shell from "./shell";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Shell />}>
      <Route element={<HomePage />} index />
      <Route path="thing-defs">
        <Route element={<ThingDefsPage />} index />
      </Route>
    </Route>
  )
);

export default router;
