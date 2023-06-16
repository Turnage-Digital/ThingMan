import React from "react";
import { Box, Container } from "@mui/material";
import { Outlet } from "react-router-dom";

const ContentSection = () => {
  return (
    <Container component="main" fixed>
      <Box sx={(theme) => ({ ...theme.mixins.toolbar })} />
      <Outlet />
    </Container>
  );
};

export default ContentSection;
