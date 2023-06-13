import { Box } from "@mui/material";
import React, { FC, useCallback, useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

import { SignIn, useAuth } from "./auth";
import { ContentSection, SideSection, TopSection } from "./layout";
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
    <Box
      sx={{
        display: "flex",
      }}
    >
      <TopSection onDrawerToggle={handleDrawerToggle} />
      <SideSection
        drawerOpen={drawerOpen}
        onDrawerToggle={handleDrawerToggle}
        selectedRoute={selectedRoute}
        onRouteSelected={handleRouteSelection}
      />
      <ContentSection />
    </Box>
  );
};

export default Shell;
