import {
    // Button,
    Card,
    CardContent,
    CardHeader,
    Divider,
    Grid,
    Typography
} from "@mui/material";

const EventDetailBottom = () => {
    // const { item } = props;
    return (
        <>
            <Card>
                <CardHeader title="Detail" />
                <CardContent sx={{ mb: 10 }}>
                    <Grid container spacing={3}>
                        <Grid item xs={12}>
                            <Divider>Event</Divider>
                        </Grid>
                        <Grid
                            item
                            lg={12}
                            md={12}
                            xs={12}
                        >
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Tại sao nên tham gia sự kiện này?

                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.topReasons?.map((reason, index) => (
                                    <li key={index}>{reason}</li>
                                ))} */}
                                 <li>Tham gia sự kiện này sẽ mang đến cho bạn một trải nghiệm chưa từng có về âm nhạc</li>
                                 <li>Tìm được một nửa còn lại của mình trong lễ hội âm nhạc lớn nhất FPT</li>
                                 <li>Một trong những sự kiện âm nhạc tầm cỡ nhất từng được tổ chức</li>
                                 <li>Là câu lạc bộ chuyên tổ chức sự kiện được thành lập từ 10 năm về trước</li>
                                 <li>Tham gia sự kiện này sẽ mang đến cho bạn một trải nghiệm chưa từng có về âm nhạc</li>
                                 <li>Tham gia sự kiện này sẽ mang đến cho bạn một trải nghiệm chưa từng có về âm nhạc</li>
                            </Typography>
                            <br />
                            <Typography color="textPrimary" gutterBottom variant="h4">
                               Video
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.company?.description} */}
                                Link video
                            </Typography>
                        </Grid>
                    </Grid>
                </CardContent>
            </Card>
        </>
    )
}

export default EventDetailBottom
