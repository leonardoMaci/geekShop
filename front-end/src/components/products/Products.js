import { Component } from "react";
import { Container } from "@mui/system";
import axios from "axios";
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DeleteIcon from '@mui/icons-material/Delete';
import { blue, red } from "@mui/material/colors";
import { Edit } from "@mui/icons-material";
import { Link } from "@mui/material";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: blue[900],
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

class ProductIndex extends Component {
    constructor(props) {
        super(props);
    }
    state = { products: [ {id: 1, nM_Product: "camisa", category: "roupa", "price":22.20}, {id: 2, Nm_produto: "camisa", category: "roupa", "price":22.20}] }

    baseUrl = "https://localhost:5180/api/v1/Product";

    pedidoGet = async() => {
        await axios.get(this.baseUrl)
        .then(Response => {
            this.setState({ products: Response.data})
        }).catch(error =>{
            console.log(error);
        })
    }

    componentDidMount() {
        this.pedidoGet();
    }

    render() { 
        return (
            <>
                <Container maxWidth="lg">
                    <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 700 }} aria-label="customized table">
                            <TableHead>
                              <TableRow>
                                  <StyledTableCell>Product Name</StyledTableCell>
                                  <StyledTableCell>Category</StyledTableCell>
                                  <StyledTableCell>Price</StyledTableCell>
                                  <StyledTableCell>Actions</StyledTableCell>
                              </TableRow>
                            </TableHead>
                            <TableBody>
                            {this.state.products.map((product) => (
                                <StyledTableRow key={product.id}>
                                  <StyledTableCell component="th" scope="row">
                                    {product.id} - {product.nM_Product}
                                  </StyledTableCell>
                                  <StyledTableCell>{product.category}</StyledTableCell>
                                  <StyledTableCell>{product.price}</StyledTableCell>
                                  <StyledTableCell>
                                    <Link>                                    
                                      <DeleteIcon sx={{ color: red[900]}}></DeleteIcon>                                    
                                    </Link>
                                    <Edit sx={{color: blue[900]}}></Edit> 
                                  </StyledTableCell>
                                </StyledTableRow>
                            ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Container>
            </>
          );
    }
}
 
export default ProductIndex;