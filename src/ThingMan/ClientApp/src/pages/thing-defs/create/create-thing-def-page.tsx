import React from "react";
import { Box, Paper, Stack, Typography } from "@mui/material";

const CreateThingDefPage = () => {
  return (
    <Stack spacing={4} sx={{ pt: 2 }}>
      <Box sx={{ display: "flex" }}>
        <Box sx={{ flexGrow: 1 }}>
          <Typography variant="h4" component="h1">
            Create Thing Definition
          </Typography>
        </Box>
      </Box>

      <Paper />
    </Stack>
  );
};

export default CreateThingDefPage;
