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
                            <Divider>Job</Divider>
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
                            </Typography>
                            <br />
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Mô tả về sự kiện
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.description} */}
                                <li>Một trong những sự kiện âm nhạc tầm cỡ nhất từng được tổ chức</li>
                            </Typography>
                            <br />
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Về câu lạc bộ chúng tôi
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.aboutOurTeam ? item?.aboutOurTeam : "_"} */}
                                <li>Là câu lạc bộ chuyên tổ chức sự kiện được thành lập từ 10 năm về trước</li>
                            </Typography>
                            <br />
                            {/* whyYouWillLove */}
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Lý do bạn sẽ yêu thích sự kiện này của chúng tôi
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >
                                {/* {item?.whyYouWillLove} */}
                                <li>Tham gia sự kiện này sẽ mang đến cho bạn một trải nghiệm chưa từng có về âm nhạc</li>
                            </Typography>
                            <br />
                            {/* benefits */}
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Lợi ích
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >
                                {/* {item?.benefits?.map((benefit, index) => (
                                    <li key={index}>{benefit}</li>
                                ))} */}
                                <li>Tham gia sự kiện này sẽ mang đến cho bạn một trải nghiệm chưa từng có về âm nhạc</li>
                            </Typography>
                            <br />
                            
                           
                        </Grid>
                        <Grid item xs={12}>
                            <Divider>Về câu lạc bộ</Divider>
                        </Grid>
                        <Grid
                            item
                            lg={12}
                            md={12}
                            xs={12}
                        >
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Club
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.company?.name} */}
                               FPT Event Club

                            </Typography>
                            <br />
                            <Typography color="textPrimary" gutterBottom variant="h4">
                                Liên hệ với chúng tôi
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >

                                {/* {item?.company?.address} */}
                                https://www.facebook.com/FPTEventClub
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
