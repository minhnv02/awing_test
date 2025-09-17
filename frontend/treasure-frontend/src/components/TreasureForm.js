import { useState } from "react";
import { TextField, Button, Grid, Typography, Paper } from "@mui/material";
import axios from "axios";

export default function TreasureForm() {
  const [n, setN] = useState(3);
  const [m, setM] = useState(3);
  const [p, setP] = useState(3);
  const [matrix, setMatrix] = useState([]);
  const [result, setResult] = useState(null);

  const generateMatrix = () => {
    const newMatrix = Array.from({ length: n }, () =>
      Array.from({ length: m }, () => 1)
    );
    setMatrix(newMatrix);
  };

  const handleCellChange = (i, j, value) => {
    const updated = [...matrix];
    updated[i][j] = parseInt(value) || 0;
    setMatrix(updated);
  };

  // Submit
  const handleSubmit = async () => {
    try {
      const req = { n, m, p, matrix };
      const res = await axios.post("http://localhost:5205/api/Treasure/find", req);
      setResult(res.data);
    } catch (err) {
      console.error(err);
      alert("Có lỗi xảy ra khi gọi API!");
    }
  };

  return (
    <Paper sx={{ p: 3, maxWidth: 800, margin: "20px auto" }}>
      <Typography variant="h5" gutterBottom>
        Treasure Hunt Input
      </Typography>

      <Grid container spacing={2}>
        <Grid item xs={4}>
          <TextField
            label="Số hàng (n)"
            type="number"
            value={n}
            onChange={(e) => setN(parseInt(e.target.value))}
            fullWidth
          />
        </Grid>
        <Grid item xs={4}>
          <TextField
            label="Số cột (m)"
            type="number"
            value={m}
            onChange={(e) => setM(parseInt(e.target.value))}
            fullWidth
          />
        </Grid>
        <Grid item xs={4}>
          <TextField
            label="Số loại rương (p)"
            type="number"
            value={p}
            onChange={(e) => setP(parseInt(e.target.value))}
            fullWidth
          />
        </Grid>
      </Grid>

      <Button
        variant="contained"
        sx={{ mt: 2 }}
        onClick={generateMatrix}
      >
        Tạo ma trận
      </Button>

      {matrix.length > 0 && (
        <>
          <Typography variant="h6" sx={{ mt: 2 }}>
            Nhập ma trận ({n}x{m})
          </Typography>
          <Grid container spacing={1}>
            {matrix.map((row, i) =>
              row.map((val, j) => (
                <Grid item xs={1} key={`${i}-${j}`}>
                  <TextField
                    type="number"
                    value={val}
                    inputProps={{ min: 1, max: p }}
                    onChange={(e) => handleCellChange(i, j, e.target.value)}
                  />
                </Grid>
              ))
            )}
          </Grid>

          <Button
            variant="contained"
            color="success"
            sx={{ mt: 3 }}
            onClick={handleSubmit}
          >
            Tính nhiên liệu tối thiểu
          </Button>
        </>
      )}

      {result !== null && (
        <Typography variant="h6" sx={{ mt: 2 }}>
          Nhiên liệu tối thiểu: {result.toFixed(5)}
        </Typography>
      )}
    </Paper>
  );
}
