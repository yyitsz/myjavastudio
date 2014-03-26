/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studybatch.ch01.batch;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.IOUtils;
import org.springframework.batch.core.StepContribution;
import org.springframework.batch.core.scope.context.ChunkContext;
import org.springframework.batch.core.step.tasklet.Tasklet;
import org.springframework.batch.repeat.RepeatStatus;
import org.springframework.core.io.Resource;

/**
 *
 * @author yyi
 */
public class DecompressTasklet implements Tasklet {

    private Resource inputResource;
    private String targetDirectory;
    private String targetFile;

    @Override
    public RepeatStatus execute(StepContribution contribution, ChunkContext chunkContext) throws Exception {
        ZipInputStream zis = new ZipInputStream(new BufferedInputStream(inputResource.getInputStream()));
        File targetDir = new File(targetDirectory);
        if (!targetDir.exists()) {
            FileUtils.forceMkdir(targetDir);
        }
        File target = new File(targetDir,targetFile);
        
        //ZipEntry entry = null;
        BufferedOutputStream outstream = null;
        while(zis.getNextEntry() != null){
            if(target.exists() == false){
                target.createNewFile();
            }
            
            FileOutputStream fos = new FileOutputStream(target);
            outstream = new BufferedOutputStream(fos);
            IOUtils.copy(zis, fos);
            outstream.flush();
            outstream.close();
        }
        
        zis.close();
        if(target.exists() == false){
            throw new RuntimeException("Can not decompress any archived file.");
        }
        
        return RepeatStatus.FINISHED;
    }

    public Resource getInputResource() {
        return inputResource;
    }

    public void setInputResource(Resource inputResource) {
        this.inputResource = inputResource;
    }

    public String getTargetDirectory() {
        return targetDirectory;
    }

    public void setTargetDirectory(String targetDirectory) {
        this.targetDirectory = targetDirectory;
    }

    public String getTargetFile() {
        return targetFile;
    }

    public void setTargetFile(String targetFile) {
        this.targetFile = targetFile;
    }
}
