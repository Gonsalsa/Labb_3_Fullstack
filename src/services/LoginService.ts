export const LoginUser = async (UserName: string, Password: string) => {
  const result = await fetch("http://localhost:5019/api/User/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ UserName, Password }),
  });

  if (!result.ok) {
    throw new Error("Login misslyckades");
  }

  const data = await result.json();


  return data;
};
