import React, { FC, useState } from "react";
import { AccountCircle, Menu as MenuIcon } from "@mui/icons-material";
import {
  AppBar,
  Box,
  Button,
  Container,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { useNavigate } from "react-router-dom";

import { NavItem } from "./nav-item";

interface Props {
  logoutUrl: string | null;
  navigation: NavItem[];
}

const TopSection: FC<Props> = ({ logoutUrl, navigation }) => {
  const navigate = useNavigate();
  const logoutLabel = "Logout";

  const [userAnchorElement, setUserAnchorElement] =
    useState<HTMLButtonElement | null>(null);
  const handleOpenUserMenu = (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    setUserAnchorElement(event.currentTarget);
  };
  const handleCloseUserMenu = () => {
    setUserAnchorElement(null);
  };

  const [navAnchorElement, setNavAnchorElement] =
    useState<HTMLButtonElement | null>(null);
  const handleOpenNavMenu = (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    setNavAnchorElement(event.currentTarget);
  };
  const handleCloseNavMenu = () => {
    setNavAnchorElement(null);
  };
  const handleNavMenuNavigation = (href: string) => {
    setNavAnchorElement(null);
    navigate(href);
  };

  const handleLogoutClick = () => {
    setUserAnchorElement(null);
    const logoutLink = document.createElement("a");
    logoutLink.href = logoutUrl!;
    logoutLink.click();
  };

  return (
    <AppBar
      position="fixed"
      sx={{
        backgroundColor: "#fff",
      }}
    >
      <Container maxWidth={false}>
        <Toolbar disableGutters>
          {/* desktop */}
          <Box sx={{ display: { xs: "none", md: "flex" } }} />
          <Box sx={{ flexGrow: 1, px: 2, display: { xs: "none", md: "flex" } }}>
            {navigation.map((item) => (
              <Button
                key={item.name}
                onClick={() => handleNavMenuNavigation(item.href)}
                sx={{ my: 2, display: "block" }}
              >
                {item.name}
              </Button>
            ))}
          </Box>

          {/* mobile */}
          <Box sx={{ display: { xs: "flex", md: "none" } }}>
            <IconButton color="primary" onClick={handleOpenNavMenu}>
              <MenuIcon />
            </IconButton>
            <Menu
              anchorEl={navAnchorElement}
              open={Boolean(navAnchorElement)}
              onClose={handleCloseNavMenu}
            >
              {navigation.map((item) => (
                <MenuItem
                  key={item.name}
                  onClick={() => handleNavMenuNavigation(item.href)}
                >
                  {item.name}
                </MenuItem>
              ))}
            </Menu>
          </Box>
          <Box
            sx={{
              flexGrow: 1,
              justifyContent: "center",
              display: { xs: "flex", md: "none" },
              mr: 2,
            }}
          />

          {/* both */}
          <Box sx={{ flexGrow: 0 }}>
            <IconButton color="primary" onClick={handleOpenUserMenu}>
              <AccountCircle />
            </IconButton>
            <Menu
              anchorEl={userAnchorElement}
              open={Boolean(userAnchorElement)}
              onClose={handleCloseUserMenu}
            >
              {logoutUrl && (
                <MenuItem onClick={handleLogoutClick}>
                  <Typography textAlign="center">{logoutLabel}</Typography>
                </MenuItem>
              )}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default TopSection;
