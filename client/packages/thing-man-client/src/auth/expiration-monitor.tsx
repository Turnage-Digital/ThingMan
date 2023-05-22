import React, { FC, useEffect } from "react";

import { RootState, useAppSelector } from "../store";

export const ExpirationMonitor: FC = () => {
  const exp = useAppSelector((state: RootState) => state.auth.exp);
  const logoutUrl = useAppSelector((state: RootState) => state.auth.logoutUrl);

  useEffect(() => {
    if (exp && logoutUrl) {
      const interval: NodeJS.Timer = setInterval(() => {
        const now = Date.now();
        if (exp < now) {
          const logoutLink = document.createElement("a");
          logoutLink.href = logoutUrl;
          logoutLink.click();
        }
      }, 60000);

      return () => clearInterval(interval);
    }
  }, [exp, logoutUrl]);

  return null;
};
