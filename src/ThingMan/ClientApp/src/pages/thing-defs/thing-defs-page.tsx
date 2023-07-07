import { RocketLaunch } from "@mui/icons-material";
import { Box, Button, Drawer, Paper, Stack, Typography } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

import { CreateThingDefPage } from "./create";

const ThingDefsPage = () => {
  const navigate = useNavigate();

  const [drawerOpen, setDrawerOpen] = useState(false);

  const handleCreateNewThingDefClicked = () => {
    setDrawerOpen(true);
  };

  return (
    <>
      <Stack spacing={4} sx={{ pt: 2 }}>
        <Box sx={{ display: "flex" }}>
          <Box sx={{ flexGrow: 1 }}>
            <Typography component="h1" variant="h4">
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

      <Drawer
        anchor="right"
        open={drawerOpen}
        onClose={() => setDrawerOpen(false)}
      >
        <CreateThingDefPage onClose={() => setDrawerOpen(false)} />
      </Drawer>
    </>
  );
};

export default ThingDefsPage;
