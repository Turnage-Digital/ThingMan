import { Alert, Snackbar, Stack, styled, useTheme } from "@mui/material";
import React, { FC } from "react";

import { ContentSection, NavItem, TopSection } from "./layout";
import { RootState, shellSlice, useAppDispatch, useAppSelector } from "./store";

const { setAlert } = shellSlice.actions;

const StyledSnackbar = styled(Snackbar)(({ theme }) => ({
  [theme.breakpoints.up("xs")]: {
    padding: theme.spacing(1),
  },
}));

const Shell: FC = () => {
  const dispatch = useAppDispatch();
  const theme = useTheme();
  const loading = useAppSelector((state: RootState) => state.shell.loading);
  const logoutUrl = useAppSelector((state: RootState) => state.auth.logoutUrl);
  const alert = useAppSelector((state: RootState) => state.shell.alert);

  const navigation: NavItem[] = [{ name: "Dashboard", href: "/" }];

  const handleClose = (
    event?: React.SyntheticEvent | Event,
    reason?: string
  ) => {
    if (reason === "clickaway") {
      return;
    }

    dispatch(setAlert(null));
  };

  let alertElement: JSX.Element | undefined;
  if (alert !== null) {
    if (alert.severity === "success") {
      alertElement = (
        <Alert
          variant="filled"
          elevation={3}
          severity="success"
          onClose={handleClose}
        >
          {alert.message}
        </Alert>
      );
    } else {
      alertElement = (
        <Alert
          variant="filled"
          elevation={3}
          severity="error"
          onClose={handleClose}
        >
          {alert.message}
        </Alert>
      );
    }
  }

  return (
    <Stack
      sx={{
        minWidth: "100%",
        height: "100vh",
        bgcolor: theme.palette.grey.A100,
      }}
    >
      <TopSection logoutUrl={logoutUrl} navigation={navigation} />
      <ContentSection loading={loading} />
      <StyledSnackbar
        autoHideDuration={6000}
        open={alert !== null}
        onClose={handleClose}
      >
        {alertElement}
      </StyledSnackbar>
    </Stack>
  );
};

export default Shell;
