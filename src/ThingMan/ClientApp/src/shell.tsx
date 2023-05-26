import { Stack } from "@mui/material";
import React, { FC } from "react";
import { Outlet } from "react-router-dom";

const Shell: FC = () => {
  return (
    <Stack
      sx={{
        minWidth: "100%",
        height: "100vh",
      }}
    >
      <Outlet />
    </Stack>
  );
};

export default Shell;
