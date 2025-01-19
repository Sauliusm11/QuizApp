import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Link from '@mui/material/Link';

function Header() {
  return (
    <>
     <AppBar sx={{ bgcolor: "white"}}>
      <Box
      sx={{
          display: 'flex',
          flexWrap: 'wrap',
          justifyContent: 'center',
          typography: 'body1',
          '& > :not(style) ~ :not(style)': {
            ml: 2,
          },
        }}
      >
        <Link href="/quiz" underline="hover">
          {'Quiz'}
        </Link>
        <Link href="/high-scores" underline="hover">
          {'HighScores'}
        </Link>
      </Box>
    </AppBar>
    </>
  );
}

export default Header;
