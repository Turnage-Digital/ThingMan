import { Snackbar, Stack, styled, useTheme } from "@mui/material";
import React, { FC } from "react";

const Shell: FC = () => {
  const theme = useTheme();

  return (
    <Stack
      sx={{
        minWidth: "100%",
        height: "100vh",
      }}
    >
      Start Here...
    </Stack>
  );
};

export default Shell;
