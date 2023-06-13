import { Dashboard } from "@mui/icons-material";
import { Box, Drawer, Hidden, List } from "@mui/material";
import React, { FC } from "react";

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
  const drawerWidth: 240 = 240;
  const drawer = (
    <>
      <Box sx={(theme) => ({ width: drawerWidth, ...theme.mixins.toolbar })} />
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
        <Drawer
          variant="permanent"
          anchor="left"
          sx={{
            width: drawerWidth,
          }}
        >
          {drawer}
        </Drawer>
      </Hidden>
      <Hidden smUp>
        <Drawer
          variant="temporary"
          anchor="left"
          open={drawerOpen}
          onClose={onDrawerToggle}
          sx={{
            width: drawerWidth,
          }}
        >
          {drawer}
        </Drawer>
      </Hidden>
    </>
  );
};

export default SideSection;
