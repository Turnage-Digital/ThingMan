import React, { FC } from "react";
import { Box, Drawer, Hidden, List } from "@mui/material";
import { Dashboard } from "@mui/icons-material";

import RouterListItem from "../../router-list-item";

interface Props {
  drawerOpen: boolean;
  onDrawerToggle: (open: boolean) => void;
  selectedRoute: string;
  onRouteSelected: (route: string) => void;
}

const SideSection: FC<Props> = ({
  drawerOpen,
  onDrawerToggle,
  selectedRoute,
  onRouteSelected,
}: Props) => {
  const drawerWidth = 240;
  const drawer = (
    <>
      <Box
        sx={(theme) => ({
          width: drawerWidth,
          display: "flex",
          alignItems: "center",
          padding: theme.spacing(0, 1),
          ...theme.mixins.toolbar,
        })}
      >
        <Box
          sx={(theme) => ({ flexGrow: 1, padding: theme.spacing(1, 0, 0, 1) })}
        >
          Thing Man
        </Box>
      </Box>
      <List>
        <RouterListItem
          to="/"
          primary="Dashboard"
          icon={<Dashboard />}
          selected={selectedRoute.includes("/")}
          onClick={() => onRouteSelected("/")}
        />
      </List>
    </>
  );

  return (
    <>
      <Hidden smDown>
        <Drawer sx={{ width: drawerWidth }} variant="permanent" anchor="left">
          {drawer}
        </Drawer>
      </Hidden>
      <Hidden smUp>
        <Drawer
          sx={{ width: drawerWidth }}
          variant="temporary"
          anchor="left"
          open={drawerOpen}
          onClose={onDrawerToggle}
        >
          {drawer}
        </Drawer>
      </Hidden>
    </>
  );
};

export default SideSection;
