import React from "react";
import { Box, Button, Stack } from "@mui/material";
import { Add } from "@mui/icons-material";
import { useNavigate } from "react-router-dom";

const DashboardPage = () => {
  const navigate = useNavigate();

  const handleCreateNewThingDefClicked = () => {
    navigate("/thing-def/create");
  };

  return (
    <Stack spacing={4} sx={{ mb: 4 }}>
      <Box alignItems="center" sx={{ display: "flex" }}>
        <Box sx={{ flexGrow: 1 }} />
        <Button
          variant="contained"
          startIcon={<Add />}
          onClick={handleCreateNewThingDefClicked}
        >
          create a new thing definition
        </Button>
      </Box>
    </Stack>
  );
};

export default DashboardPage;
