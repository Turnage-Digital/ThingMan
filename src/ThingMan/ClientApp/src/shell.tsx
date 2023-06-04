import { Stack } from "@mui/material";
import React, { FC, useCallback, useEffect, useState } from "react";
import { Outlet, useLocation } from "react-router-dom";

import { SignIn, useAuth } from "./hooks";
import { ContentSection, TopSection, SideSection } from "./layout";
import Loading from "./loading";

const Shell: FC = () => {
  const { loading, signedIn } = useAuth();
  const location = useLocation();

  const [drawerOpen, setDrawerOpen] = useState(false);
  const [selectedRoute, setSelectedRoute] = useState("");

  function handleDrawerToggle() {
    setDrawerOpen(!drawerOpen);
  }

  const handleRouteSelection = useCallback((route: string) => {
    setSelectedRoute(route);
    setDrawerOpen(false);
  }, []);

  useEffect(
    () => handleRouteSelection(location.pathname),
    [handleRouteSelection, location.pathname]
  );

  if (loading) {
    return <Loading />;
  }

  if (!signedIn) {
    return <SignIn />;
  }

  return (
    <Stack
      sx={{
        minWidth: "100%",
        height: "100vh",
      }}
    >
      <SideSection
        drawerOpen={drawerOpen}
        onDrawerToggle={handleDrawerToggle}
        selectedRoute={selectedRoute}
        onRouteSelected={handleRouteSelection}
      />
      <TopSection onDrawerToggle={handleDrawerToggle} />
      <ContentSection>
        <Outlet />
      </ContentSection>
    </Stack>
  );
};

export default Shell;
