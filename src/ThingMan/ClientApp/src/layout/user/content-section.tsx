import { Box, Container } from "@mui/material";
import React, { FC } from "react";
import { Outlet } from "react-router-dom";

const ContentSection: FC = () => {
  return (
    <Container sx={{ pt: 4 }}>
      <Box sx={(theme) => ({ ...theme.mixins.toolbar })} />
      <Outlet />
    </Container>
  );
};

export default ContentSection;
