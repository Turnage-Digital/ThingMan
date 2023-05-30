const baseUrl = `${process.env.PUBLIC_URL}/api/users`;

export const signIn = async (username: string, password: string) => {
  const input = { username, password };
  const request = new Request(`${baseUrl}/sign-in`, {
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
};
