<<<<<<< HEAD
import { useEffect, useState } from "react";
import axios from "axios";
const EventDetail = () => {
    return(
        <div className="flex">
        
            <form className='Create-event max-w-[700px]' method='post' >
                <div className='form-row' >
                    <label className="form-label ">Tên sự kiện</label>
                    <input className='form-input' type="text" name="event_name" required />
                </div>
                <div className='form-row' >
                    <label className="form-label">Thời gian diễn ra sự kiện</label>
                    <input className="form-input" type="datetime-local" name="event_time" required />
                </div>
                <div className='form-row' >
                    <label className="form-label">Trạng thái</label>
                    <select className="form-input" name="event_status" required>
                        <option value="true">Online</option>
                        <option value="false">Offline</option>
                    </select>
                </div>
                <div className='form-row' >
                    <label className="form-label">Địa điểm tổ chức</label>
                    <select className="form-input" name="event_location" required>
                        <option value="HTA">Hội trường A</option>
                        <option value="HTB">Hội trường B</option>
                    </select>
                </div>
                <div className='form-row' >
                    <label className="form-label">Thể loại sự kiện</label>
                    <select className="form-input" name="event_category" required>
                        <option value="Music">Âm nhạc</option>
                        <option value="Art">Hội họa</option>
                    </select>
                </div>
                <div className='form-row' >
                    <label className="form-label">Link thanh toán (Momo)</label>
                    <input className="form-input" type="url" name="event_payment" required />
                </div>
                <div className='form-row' >
                    <label className='form-label'>Nội dung/Thông tin sự kiện</label>
                    <textarea className='form-input h-[200px]' name="message" required />
                </div>
                <div className='form-row' >
                    <input className="form-submit bg-[#000050]" type="submit" value='Đăng bài' />
                </div>
            </form>
       
    </div>
=======
import {
    Box,
    CircularProgress, Container, Grid
} from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
// import Paper from "@mui/material";
import axios from "axios";
import StudentJobDetailHeader from "./eventdetailheader";
import StudentJobDetailBottom from "./eventdetailbottom";

const StudentJobDetail = () => {
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
                        <StudentJobDetailHeader />



                    </Grid>
                    <Grid item lg={12} md={12} xs={12}>
                        {/* <StudentJobDetailBottom item={job} /> */}
                        <StudentJobDetailBottom />
                    </Grid>

                </Grid>


            </Container>
        </Box>
>>>>>>> frontend-Phu
    )
}

export default StudentJobDetail
