import { Close } from "@mui/icons-material";
import React, { FormEvent } from "react";
import {
  Box,
  Button,
  Divider,
  IconButton,
  Stack,
  TextField,
  Typography,
} from "@mui/material";

import StatusDefField from "./status-def-field";

interface Props {
  onClose: () => void;
}

const CreateThingDefPage = ({ onClose }: Props) => {
  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);

    const username = data.get("name")?.toString();
  };

  const handleClose = () => {
    onClose();
  };

  return (
    <Box
      component="form"
      onSubmit={handleSubmit}
      sx={(theme) => ({
        display: "flex",
        flexDirection: "column",
        flexGrow: 1,
        width: 500,
      })}
    >
      <Box
        sx={(theme) => ({
          display: "flex",
          alignItems: "center",
          padding: 2,
          ...theme.mixins.toolbar,
        })}
      >
        <Typography variant="h5" sx={{ flexGrow: 1 }}>
          Create a Thing Definition
        </Typography>
        <IconButton onClick={handleClose}>
          <Close />
        </IconButton>
      </Box>

      <Stack spacing={4} sx={{ p: 2 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          name="name"
          id="name"
          label="Name your Thing"
        />

        <Divider />

        <StatusDefField />
      </Stack>

      <Box
        sx={(theme) => ({
          position: "absolute",
          bottom: 0,
          backgroundColor: theme.palette.background.default,
          width: "100%",
          padding: 2,
          borderTop: 1,
          borderColor: theme.palette.divider,
          display: "flex",
          justifyContent: "flex-end",
        })}
      >
        <Button type="submit" variant="contained" size="large">
          Create
        </Button>
      </Box>
    </Box>
  );
};

export default CreateThingDefPage;
