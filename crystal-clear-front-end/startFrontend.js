const detectPort = require("detect-port");
const { exec } = require("child_process");

detectPort(3000, (err, availablePort) => {
  if (err) {
    console.error(err);
    process.exit(1);
  }

  const port = availablePort;

  exec(`cross-env PORT=${port} npm start`, (err, stdout, stderr) => {
    if (err) {
      console.error(`exec error: ${err}`);
      return;
    }
    console.log(stdout);
    console.error(stderr);
  });
});
