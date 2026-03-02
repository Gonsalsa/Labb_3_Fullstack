export const RegisterService = async (
  userName: string,
  email: string,
  password: string,
) => {
  const result = await fetch("http://localhost:5019/api/User/register", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userName, email, password }),
  });

  if (!result.ok) {
    let errorMessage = "Registrering misslyckades";
    try {
      const text = await result.text();
      if (text) errorMessage += `: ${text}`
    } catch {}
    throw new Error(errorMessage);
  }

  const text = await result.text();

  if (!text) return;
  return JSON.parse(text);
};
