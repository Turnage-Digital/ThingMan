import { ClaimDto } from "./dtos";

interface IUserApi {
  signIn(username: string, password: string): Promise<{ succeeded: boolean }>;

  getClaims(): Promise<ClaimDto[]>;

  signOut(): Promise<void>;
}

class UserApi implements IUserApi {
  private readonly baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public async signIn(
    username: string,
    password: string
  ): Promise<{ succeeded: boolean }> {
    const input = { username, password };
    const request = new Request(`${this.baseUrl}/sign-in`, {
      headers: new Headers({
        "Content-Type": "application/json",
      }),
      method: "POST",
      body: JSON.stringify(input),
    });
    const response = await fetch(request);
    if (!response.ok) {
      throw new Error("Failed to sign in.");
    }
    const retval = await response.json();
    return retval;
  }

  public async getClaims(): Promise<ClaimDto[]> {
    const request = new Request(`${this.baseUrl}/claims`, {
      headers: new Headers({
        "Content-Type": "application/json",
      }),
      method: "GET",
    });
    const response = await fetch(request);
    if (!response.ok) {
      throw new Error("Failed to get claims.");
    }
    const retval = await response.json();
    return retval;
  }

  public async signOut(): Promise<void> {
    const request = new Request(`${this.baseUrl}/sign-out`, {
      method: "POST",
    });
    const response = await fetch(request);
    if (!response.ok) {
      throw new Error("Failed to sign out.");
    }
  }
}

export { UserApi };
export type { IUserApi };
