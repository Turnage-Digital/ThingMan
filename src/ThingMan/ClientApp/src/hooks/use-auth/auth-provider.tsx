import React, { useState, PropsWithChildren, FC, useMemo } from "react";

import { IUserApi } from "../../api";
import { ClaimDto } from "../../api/dtos";

import AuthContext from "./auth-context";

type Props = PropsWithChildren<{ userApi: IUserApi }>;

const AuthProvider: FC<Props> = ({ children, userApi }) => {
  const [isSignedIn, setIsSignedIn] = useState<boolean>(false);
  const [claims, setClaims] = useState<ClaimDto[]>([]);
  const [error, setError] = useState<string | undefined>(undefined);

  const authContextValue = useMemo(() => {
    const signInLocal = async (username: string, password: string) => {
      const result = await userApi.signIn(username, password);
      if (result.succeeded) {
        const claims = await userApi.getClaims();

        setClaims(claims);
        setIsSignedIn(result.succeeded);
      } else {
        setError("Invalid username or password.");
      }
    };

    const signOutLocal = async () => {
      await userApi.signOut();

      setClaims([]);
      setIsSignedIn(false);
    };

    return {
      isSignedIn,
      claims,
      signIn: signInLocal,
      signOut: signOutLocal,
      error,
    };
  }, [userApi, isSignedIn, claims, error]);

  return (
    <AuthContext.Provider value={authContextValue}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
