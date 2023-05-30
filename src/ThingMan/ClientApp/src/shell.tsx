import React, { FC } from "react";
import { Outlet } from "react-router-dom";

import { SignIn } from "./auth";
import useAuth from "./auth/use-auth";

const Shell: FC = () => {
  const { isLoggedIn } = useAuth();

  if (!isLoggedIn) {
    return <SignIn />;
  }

  return <Outlet />;
};

export default Shell;
