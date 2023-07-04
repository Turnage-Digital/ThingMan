import { Box } from "@mui/material";
import React, { ReactElement, useCallback, useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

import { SignInForm, useAuth } from "./auth";
import { ContentSection, SideSection, TopSection } from "./layout";
import Loading from "./loading";

const Shell = () => {
  const { loading, signedIn } = useAuth();
  const location = useLocation();
  const navigate = useNavigate();

  const [drawerOpen, setDrawerOpen] = useState(false);
  const [selectedRoute, setSelectedRoute] = useState("");

  const handleRouteSelection = useCallback(
    (route: string) => {
      setSelectedRoute(route);
      setDrawerOpen(false);
      navigate(route);
    },
    [navigate]
  );

  useEffect(
    () => handleRouteSelection(location.pathname),
    [handleRouteSelection, location.pathname]
  );

  const handleDrawerToggle = () => {
    setDrawerOpen(!drawerOpen);
  };

  let content: ReactElement;
  if (loading) {
    content = <Loading />;
  } else if (signedIn) {
    content = (
      <>
        <TopSection onDrawerToggle={handleDrawerToggle} />
        <SideSection
          drawerOpen={drawerOpen}
          onDrawerToggle={handleDrawerToggle}
          selectedRoute={selectedRoute}
          onRouteSelected={handleRouteSelection}
        />
        <ContentSection />
      </>
    );
  } else {
    content = <SignInForm />;
  }

  return <Box sx={{ display: "flex" }}>{content}</Box>;
};

export default Shell;
