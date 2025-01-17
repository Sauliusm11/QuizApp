import { useEffect, useState } from 'react'
import './ScorePage.css'
import axios from 'axios';
import TableContainer from '@mui/material/TableContainer';
import Table from '@mui/material/Table';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import TableBody from '@mui/material/TableBody';
import Paper from '@mui/material/Paper';
import TableCell from '@mui/material/TableCell';
import createTheme from '@mui/material/styles/createTheme';
import { ThemeProvider } from '@emotion/react';


declare module '@mui/material/styles' {
  interface Theme {
    status: {
      info: string;
    };
  }
  // allow configuration using `createTheme()`
  interface ThemeOptions {
    status?: {
      info?: string;
    };
  }
}

const theme = createTheme({
  components: {
    MuiTableRow: {
      styleOverrides: {
        root: {
          "&:nth-of-type(1)": {
            backgroundColor: "gold",
          },
          "&:nth-of-type(2)": {
            backgroundColor: "silver",
          },
          "&:nth-of-type(3)": {
            backgroundColor: "#cd7f32",
          },
        },
      },
    },
  },
});

type Score = {
  id: number;
  dateTime: string;
  points: number;
  email: string;
  };
function ScorePage() {
  const [scores, setScores] = useState<Score[]>([]);

  function GetHighScores(){
    axios({
        method: 'get',
        url: `${import.meta.env.VITE_REACT_APP_BASE_URL}/scores`,
        responseType: 'json'
    })
    .then(function (response) {
        // const data: Question[] = response.data;
        setScores(response.data)
        console.log(response.data)

    })
    .catch(function (error) {
        console.log(error)
    });
}
  useEffect(() => {
    GetHighScores()
 }, []);
  return (
    <>
      <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
          <TableCell>Score</TableCell>
          <TableCell>Email</TableCell>
          <TableCell>Date</TableCell>
          </TableRow>
          </TableHead>
          <ThemeProvider theme={theme}>
          <TableBody>
          {scores.map((score)=>(
            <TableRow>
              <TableCell>{score.points.toString()}</TableCell>
              <TableCell>{score.email}</TableCell>
              <TableCell>{new Date(score.dateTime).toUTCString()}</TableCell>
          </TableRow>))}
          </TableBody>
          </ThemeProvider>
      </Table>
    </TableContainer>

    </>
  )
}

export default ScorePage
