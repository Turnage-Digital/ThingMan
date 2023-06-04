import React, { FC } from "react";
import { Outlet } from "react-router-dom";

import { SignIn, useAuth } from "./hooks";

const Shell: FC = () => {
  const { isSignedIn } = useAuth();

  if (!isSignedIn) {
    return <SignIn />;
  }

  return <Outlet />;
};

export default Shell;
