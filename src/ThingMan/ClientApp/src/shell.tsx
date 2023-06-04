import { Stack } from "@mui/material";
import React, { FC, useCallback, useEffect } from "react";
import { Outlet, useLocation } from "react-router-dom";

import { SignIn, useAuth } from "./hooks";
import { ContentSection, TopSection, SideSection } from "./layout";
import Loading from "./loading";

const navigation: { name: string; href: string }[] = [
  { name: "Dashboard", href: "/" },
];

const Shell: FC = () => {
  const { loading, signedIn } = useAuth();
  const location = useLocation();

  const [drawerOpen, setDrawerOpen] = React.useState(false);
  const [selectedRoute, setSelectedRoute] = React.useState("");

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
