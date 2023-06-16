import { AccountCircle, Menu as MenuIcon } from "@mui/icons-material";
import {
  AppBar,
  Box,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
} from "@mui/material";
import React, { FC, useState } from "react";

import { useAuth } from "../../auth";

interface Props {
  onDrawerToggle: () => void;
}

const TopSection = ({ onDrawerToggle }: Props) => {
  const { signOut } = useAuth();

  const [anchorEl, setAnchorEl] = useState<HTMLButtonElement | null>(null);
  const handleOpenMenu = (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ): void => {
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMenu = () => {
    setAnchorEl(null);
  };

  const drawerWidth: 240 = 240;

  return (
    <AppBar
      elevation={0}
      sx={(theme) => ({
        backgroundColor: theme.palette.background.paper,
        borderBottom: `1px solid ${theme.palette.divider}`,
        [theme.breakpoints.up("sm")]: {
          width: `calc(100% - ${drawerWidth}px)`,
          ml: `${drawerWidth}px`,
        },
      })}
    >
      <Toolbar>
        <IconButton
          sx={(theme) => ({
            marginRight: theme.spacing(2),
            [theme.breakpoints.up("sm")]: {
              display: "none",
            },
          })}
          onClick={onDrawerToggle}
        >
          <MenuIcon />
        </IconButton>
        <Box sx={{ flexGrow: 1 }} />
        <IconButton color="default" onClick={handleOpenMenu}>
          <AccountCircle />
        </IconButton>
        <Menu
          anchorEl={anchorEl}
          keepMounted
          open={Boolean(anchorEl)}
          onClose={handleCloseMenu}
        >
          <MenuItem onClick={() => signOut()}>Sign Out</MenuItem>
        </Menu>
      </Toolbar>
    </AppBar>
  );
};

export default TopSection;
