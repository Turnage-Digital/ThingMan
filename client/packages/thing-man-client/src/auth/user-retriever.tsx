import React, { FC, useEffect } from "react";

import { authSlice, shellSlice, useAppDispatch } from "../store";

const { setLoading } = shellSlice.actions;
const { setAuth } = authSlice.actions;

interface Claim {
  type: string;
  value: string;
}

export const UserRetriever: FC = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    const request = new Request(`${process.env.PUBLIC_URL}/bff/user`, {
      headers: new Headers({
        // eslint-disable-next-line @typescript-eslint/naming-convention
        "X-CSRF": "1",
      }),
    });

    dispatch(setLoading(true));
    // eslint-disable-next-line promise/catch-or-return
    fetch(request)
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else if (response.status === 401) {
          const loginLink = document.createElement("a");

          loginLink.href = `${process.env.PUBLIC_URL}/bff/login?returnUrl=${process.env.PUBLIC_URL}`;
          loginLink.click();
        }
      })
      .then((data: Claim[]) => {
        const name = data?.find((claim) => claim.type === "name");
        const expIn = data?.find(
          (claim) => claim.type === "bff:session_expires_in"
        );
        const exp = Date.now() + parseInt(expIn?.value ?? "0", 10) * 1000;
        const logoutUrl = data?.find(
          (claim) => claim.type === "bff:logout_url"
        );

        dispatch(
          setAuth({
            name: name?.value,
            exp,
            logoutUrl: logoutUrl?.value,
          })
        );
        dispatch(setLoading(false));
      });
  }, [dispatch]);

  return null;
};
