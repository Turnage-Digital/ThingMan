import { RocketLaunch } from "@mui/icons-material";
import { Box, Button, Paper, Stack, Typography } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";

const ThingDefsPage = () => {
  const navigate = useNavigate();

  const handleCreateNewThingDefClicked = () => {
    navigate("/thing-defs/create");
  };

  return (
    <Stack spacing={4} sx={{ pt: 2 }}>
      <Box sx={{ display: "flex" }}>
        <Box sx={{ flexGrow: 1 }}>
          <Typography variant="h4" component="h1">
            Thing Definitions
          </Typography>
        </Box>
        <Button
          variant="contained"
          startIcon={<RocketLaunch />}
          onClick={handleCreateNewThingDefClicked}
        >
          create thing definition
        </Button>
      </Box>

      <Paper />
    </Stack>
  );
};

export default ThingDefsPage;
