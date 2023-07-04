import React, {FC, PropsWithChildren, useMemo, useState} from "react";

import {IUserApi} from "../api";
import {ClaimDto} from "../api/dtos";

import AuthContext from "./auth-context";

type Props = PropsWithChildren<{ userApi: IUserApi }>;

const AuthProvider: FC<Props> = ({children, userApi}) => {
    const [loading, setLoading] = useState<boolean>(false);
    const [signedIn, setSignedIn] = useState<boolean>(false);
    const [claims, setClaims] = useState<ClaimDto[]>([]);
    const [error, setError] = useState<string | null>(null);

    const authContextValue = useMemo(() => {
        const signInLocal = async (username: string, password: string) => {
            setLoading(true);
            const result = await userApi.signIn(username, password);
            if (result.succeeded) {
                const claims = await userApi.getClaims();
                setClaims(claims);
                setSignedIn(result.succeeded);
            } else {
                setError("Invalid username or password.");
            }
            setLoading(false);
        };

        const signOutLocal = async () => {
            setLoading(true);
            await userApi.signOut();
            setClaims([]);
            setSignedIn(false);
            setLoading(false);
        };

        return {
            loading,
            signedIn,
            claims,
            signIn: signInLocal,
            signOut: signOutLocal,
            error,
        };
    }, [userApi, loading, signedIn, claims, error]);

    return (
        <AuthContext.Provider value={authContextValue}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
