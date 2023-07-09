import React, { useState } from "react";
import {
  Button,
  FormControl,
  Grid,
  IconButton,
  InputAdornment,
  InputLabel,
  ListItemText,
  Menu,
  MenuItem,
  OutlinedInput,
  Select,
  Stack,
  TextField,
  Typography,
} from "@mui/material";

import { statusColors } from "../../../status-colors";

import StatusBullet from "./status-bullet";

const StatusDefField = () => {
  const [statusColor, setStatusColor] = React.useState(statusColors[0]);
  const [selectedIndex, setSelectedIndex] = React.useState(0);
  const [anchorEl, setAnchorEl] = useState<HTMLButtonElement | null>(null);
  const open = Boolean(anchorEl);

  const handleMenuItemClick = (
    event: React.MouseEvent<HTMLElement>,
    index: number
  ) => {
    setSelectedIndex(index);
    setStatusColor(statusColors[index]);
    setAnchorEl(null);
  };

  const handleOpenMenu = (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ): void => {
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMenu = () => {
    setAnchorEl(null);
  };

  return (
    <Stack spacing={2}>
      <Typography variant="h6">Statuses</Typography>

      <FormControl variant="outlined" fullWidth>
        <InputLabel htmlFor="statusName">Name Your Status</InputLabel>
        <OutlinedInput
          id="statusName"
          type="text"
          label="Name Your Status"
          endAdornment={
            <InputAdornment position="end">
              <IconButton onClick={handleOpenMenu}>
                <StatusBullet statusColor={statusColor} />
              </IconButton>
            </InputAdornment>
          }
        />
      </FormControl>

      <Menu anchorEl={anchorEl} open={open} onClose={handleCloseMenu}>
        {statusColors.map((sc, index) => (
          <MenuItem
            key={sc.name}
            selected={index === selectedIndex}
            onClick={(event) => handleMenuItemClick(event, index)}
          >
            <StatusBullet statusColor={sc} />
            <ListItemText primary={sc.name} sx={{ px: 2 }} />
          </MenuItem>
        ))}
      </Menu>
    </Stack>
  );
};

export default StatusDefField;
