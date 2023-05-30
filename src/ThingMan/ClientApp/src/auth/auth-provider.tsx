import React, { useState, PropsWithChildren, FC, useMemo } from "react";

import AuthContext from "./auth-context";

type Props = PropsWithChildren;

const AuthProvider: FC<Props> = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const authContextValue = useMemo(() => {
    const login = () => {
      setIsLoggedIn(true);
    };

    const logout = () => {
      setIsLoggedIn(false);
    };

    return { isLoggedIn, login, logout };
  }, [isLoggedIn]);

  return (
    <AuthContext.Provider value={authContextValue}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
