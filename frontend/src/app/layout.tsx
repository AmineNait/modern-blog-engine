import './globals.css';
import ThemeProviderWrapper from '../components/ThemeProviderWrapper';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang='en'>
      <head>
        <title>My Blog</title>
      </head>
      <body>
        <ThemeProviderWrapper>
          <AppBar position='static'>
            <Toolbar>
              <Typography variant='h6' component='div'>
                My Blog
              </Typography>
            </Toolbar>
          </AppBar>
          <Container maxWidth='lg'>
            <main>{children}</main>
          </Container>
          <footer
            style={{ marginTop: 'auto', padding: '1rem', textAlign: 'center' }}
          >
            <Typography variant='body2'>© 2024 My Blog</Typography>
          </footer>
        </ThemeProviderWrapper>
      </body>
    </html>
  );
}
