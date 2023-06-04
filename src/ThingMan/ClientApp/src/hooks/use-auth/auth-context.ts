import { createContext } from "react";

import { ClaimDto } from "../../api/dtos";

interface Props {
  isSignedIn: boolean;
  claims: ClaimDto[];
  signIn?: (username: string, password: string) => Promise<void>;
  signOut?: () => Promise<void>;
  error?: string;
}

const AuthContext = createContext<Props>({ isSignedIn: false, claims: [] });

export default AuthContext;
