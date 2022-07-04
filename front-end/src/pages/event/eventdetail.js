import {
    Box,
    CircularProgress, Container, Grid
} from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
// import Paper from "@mui/material";
import axios from "axios";
import EventDetailHeader from "./eventdetailheader";
import EventDetailBottom from "./eventdetailbottom";

const EventDetail = () => {
    // const { id } = useParams(); // get id job

    // const [job, setJob] = useState({});

    // console.log("id", id);

    // const [loading, setLoading] = useState(false);

    // const LoadingComponent = () => (
    //     <Box
    //         sx={{
    //             width: "100%",
    //             height: "100vh",
    //             display: "flex",
    //             justifyContent: "center",
    //             alignItems: "center",
    //         }}
    //     >
    //         <CircularProgress color="success" size={60} />

    //     </Box>
    // );


    // useEffect(() => {
    //     let isMounted = true;
    //     const getJob = async () => {
    //         try {

    //             const response = await axios.get(`/jobs/${id}`);

    //             setLoading(false);
    //             if (isMounted)
    //                 setJob(response.data);

    //         } catch (error) {
    //             console.error(error);
    //             setLoading(true);

    //             // navigate('/login', { state: { from: location }, replace: true });
    //         }
    //     };
    //     getJob()
    //     return () => {
    //         isMounted = false;
    //     };
    //     // eslint-disable-next-line react-hooks/exhaustive-deps
    // }, [])
    // if (loading) {
    //     return <LoadingComponent />;
    // }
    // console.log("Job: ", job);
    return (
        <Box sx={{ m: 20 }}>
            <Container
                sx={
                    { m: 1 }
                }
            >
                <Grid container spacing={3}>
                    <Grid item lg={12} md={12} xs={12}>
                        {/* <StudentJobDetailHeader item={job} /> */}
                        <EventDetailHeader />



                    </Grid>w
                    <Grid item lg={12} md={12} xs={12}>
                        {/* <StudentJobDetailBottom item={job} /> */}
                        <EventDetailBottom />
                    </Grid>

                </Grid>


            </Container>
        </Box>

    )
}

export default EventDetail
