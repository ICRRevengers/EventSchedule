import { Button } from "@mui/material";
import React from "react";
import Wrapper from "../../../components/layout/defaultLayout/wrapper/Wrapper";
import Sidebar from "../../../components/layout/sidebar/Sidebar";
import {TextField} from "@mui/material";
import {Box} from "@mui/material";

function UserProfile(){
    return (
        <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 1, width: '25ch' },
        }}
        noValidate
        autoComplete="off"
      >
        <div>
          <TextField
            id="outlined-read-only-input"
            label="Name"
            defaultValue="Pham Xuan Phu"
            InputProps={{
              readOnly: true,
            }}
          />         
          <TextField
            id="outlined-read-only-input"
            label="Email"
            defaultValue="sogoku1113@gmail.com"
            InputProps={{
              readOnly: true,
            }}
          />         
        </div>
      </Box>
    )
}
export default UserProfile;