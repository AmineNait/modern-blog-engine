import './globals.css';

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang='en'>
      <head>
        <title>My Blog</title>
      </head>
      <body>
        <header>
          <h1>My Blog</h1>
        </header>
        <main>{children}</main>
        <footer>
          <p>© 2024 My Blog</p>
        </footer>
      </body>
    </html>
  );
}
